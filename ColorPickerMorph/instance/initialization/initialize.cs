initialize
        super initialize.
        theSelectorDisplayMorph _ AlignmentMorph newRow
                color: Color white;
                borderWidth: 1;
                borderColor: Color red;
                hResizing: #shrinkWrap;
                vResizing: #shrinkWrap;
                addMorph: (StringMorph contents: 'theSelector').
        self addMorph: theSelectorDisplayMorph.
        self buildChartForm.
        self addMorph: (SimpleButtonMorph new borderWidth: 0;
                        label: 'x' font: nil; color: Color transparent;
                        actionSelector: #delete; target: self;
                        position: 1@0; extent: 10@9).
        selectedColor _ Color white.
        sourceHand _ nil.
        deleteOnMouseUp _ false.
        updateContinuously _ true.
        selector _ nil.
        target _ nil