using HttpClientApp.Models;
using HttpClientApp.Services;
using System.Text.Json;

namespace HttpClientApp
{
    public partial class MainForm : Form
    {
        private readonly IClientService clientService;
        private CancellationTokenSource cancellationTokenSource;

        public MainForm(IClientService clientService)
        {
            InitializeComponent();

            this.clientService = clientService;
        }

        private async void buttonSend_Click(object sender, EventArgs e)
        {

            await HandleButtonClick(async () =>
            {
                if (string.IsNullOrEmpty(textBoxUserId.Text))
                {
                    var response = await clientService.GetUsersAsync(page: null, delay: null, cancellationTokenSource.Token);
                    richTextBoxResponse.Text = JsonSerializer.Serialize(response.Content);
                }
                else
                {
                    var response = await clientService.GetUserByIdAsync(int.Parse(textBoxUserId.Text), cancellationTokenSource.Token);
                    richTextBoxResponse.Text = JsonSerializer.Serialize(response.Content);
                }
            });
        }

        private async void buttonCreateUser_Click(object sender, EventArgs e)
        {
            await HandleButtonClick(async () =>
            {
                var response = await clientService.CreateUsersAsync(new CreateUser
                {
                    Name = textBoxUserName.Text,
                    Job = textBoxUserJob.Text
                }, cancellationTokenSource.Token);

                richTextBoxResponse.Text = response.StatusCode.ToString();
            });
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonGetUsers.Enabled = true;
            buttonCancel.Enabled = false;

            cancellationTokenSource.Cancel();
        }

        private async Task HandleButtonClick(Func<Task> action)
        {
            cancellationTokenSource = new CancellationTokenSource();

            buttonGetUsers.Enabled = false;
            buttonCancel.Enabled = true;

            try
            {
                await action();
            }
            catch (TaskCanceledException ex)
            {
                richTextBoxResponse.Text = ex.Message;
            }
            catch (Exception ex)
            {
                richTextBoxResponse.Text = ex.Message;
            }
            finally
            {
                buttonGetUsers.Enabled = true;
                buttonCancel.Enabled = false;
            }
        }
    }
}