buildChartForm
        | chartForm transText |
        chartForm _ ColorChart deepCopy asFormOfDepth: Display depth.
        true "Display depth >= 16" ifTrue:
                [chartForm fill: ((TransparentBox left + 9)@0 extent: 1@9) fillColor: Color lightGray.
                chartForm fill: ((TransparentBox right - 10)@0 extent: 1@9) fillColor: Color lightGray.
                transText _ (Form extent: 63@9 depth: 1   "Where there's a will there's a way..."
                                        fromArray: #( 0 0 4194306 1024 4194306 1024 15628058 2476592640
                                                                        4887714 2485462016 1883804850 2486772764 4756618
                                                                        2485462016 4748474 1939416064 0 0)
                                        offset: 0@0).
                transText displayOn: chartForm at: 62@0.
                Display depth = 32 ifTrue:
                        ["Set opaque bits for 32-bit display"
                        chartForm fill: chartForm boundingBox rule: Form under
                                        fillColor: (Color r: 0.0 g: 0.0 b: 0.0 alpha: 1.0)]].
        chartForm borderWidth: 1.
        self form: chartForm.
        self updateSelectorDisplay.

