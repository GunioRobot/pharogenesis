initialize

        super initialize.
        self setCurrentToolTo: self toolsForPaintBrush.
        formToEdit _ Form extent: 50@40 depth: 8.
        formToEdit fill: formToEdit boundingBox fillColor: Color veryVeryLightGray.
        brushSize _ magnification _ 4.
        color _ Color veryVeryLightGray.
        brushColor _ Color red.
        backgroundColor _ Color white.
        self revert