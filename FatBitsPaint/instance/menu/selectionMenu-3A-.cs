selectionMenu: evt

        | menu |
 
        (menu _ MenuMorph new)
                addTitle: 'Edit';
                addStayUpItem.

        {
                {'edit separately'. #editSelection}.
                {'copy'. #copySelection}.
                {'cut'. #cutSelection}.
                {'paste'. #pasteSelection}
        } do: [:each |
                menu add: each first
                        target: self
                        selector: each second
                        argumentList: #()].
        menu toggleStayUp: nil.
        menu popUpEvent: evt in: self world