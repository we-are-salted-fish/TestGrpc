using System;

namespace TestGrpc.WasmClient
{
    /// <summary>
    /// 状态管理
    /// </summary>
    public class StateContainer
    {
        public string Property { get; private set; } = "Initial value from StateContainer";

        public bool IsLogin { get; private set; } = false;

        public string AccessToken { get; private set; } = null;

        public event Action OnChange;

        public void SetProperty(string value)
        {
            Property = value;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}