step

        count _ count + 1.
        count > colors size ifTrue: [count _ 1].
        self borderColor: (colors at: count)