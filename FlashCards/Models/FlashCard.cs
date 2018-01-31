using System;
using System.Collections.Generic;
using System.Text;

namespace FlashCards.Models {
    class FlashCard {
        public decimal ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public Area Area { get; set; }
        public string Category { get; set; }

    }
}
