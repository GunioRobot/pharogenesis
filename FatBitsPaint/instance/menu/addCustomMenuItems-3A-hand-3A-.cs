addCustomMenuItems: aCustomMenu hand: aHandMorph

        super addCustomMenuItems: aCustomMenu hand: aHandMorph.
        aCustomMenu 
                add: 'background color' action: #setBackgroundColor:;
                add: 'pen color' action: #setPenColor:;
                add: 'pen size' action: #setPenSize:;
                add: 'fill' action: #fill;
                add: 'magnification' action: #setMagnification:;
                add: 'accept' action: #accept;
                add: 'revert' action: #revert;
                add: 'inspect' action: #inspectForm;
                add: 'file out' action: #fileOut;
                add: 'selection...' action: #selectionMenu:;
                add: 'tools...' action: #toolMenu:;
                yourself