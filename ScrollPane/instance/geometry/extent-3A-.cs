extent: newExtent
        super extent: (newExtent max: (self scrollbarWidth + 20)@16).
        self resizeScrollBar; resizeScroller; setScrollDeltas