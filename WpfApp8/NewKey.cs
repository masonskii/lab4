using System.Diagnostics;

namespace WpfApp8 { 
    public class NewKey {

        public NewKey(string keyCode, int keyValue,
            string keyStates, string keyChar, string systemKey) {
            this.KeyCode = keyCode;
            this.KeyValue = KeyValue;
            this.KeyStates = keyStates;
            this.KeyChar = keyChar;
            this.SystemKey = systemKey;
        }

        public NewKey( ) {
        }

        public string KeyCode { get; set; }
        public int KeyValue { get; set; }
        public string KeyStates { get; set; }

        public string KeyChar { get; set; }
        public string SystemKey { get; set; }
    }
}
