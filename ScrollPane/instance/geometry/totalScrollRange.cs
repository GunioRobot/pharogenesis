totalScrollRange
	^ (scroller submorphBounds encompass: 0@0) height - (bounds height // 2) max: 0
