placeAndSize: m at: nextPlace padding: padding

	| space totalInset fullBnds left top |
	totalInset _ inset + borderWidth.
	orientation = #horizontal ifTrue: [
		space _ m minWidth max: minCellSize.
		m isLayoutMorph ifTrue: [
			(m hResizing = #spaceFill) ifTrue: [space _ space + padding].
			m layoutInWidth: space height: (bounds height - (2 * totalInset))].
	] ifFalse: [
		space _ m minHeight max: minCellSize.
		m isLayoutMorph ifTrue: [
			(m vResizing = #spaceFill) ifTrue: [space _ space + padding].
			m layoutInWidth: (bounds width - (2 * totalInset)) height: space]].

	fullBnds _ m fullBounds.
	orientation = #horizontal ifTrue: [
		left _ nextPlace.
		centering = #topLeft
			ifTrue: [top _ bounds top + totalInset].
		centering = #bottomRight
			ifTrue: [top _ bounds bottom - totalInset - fullBnds height].
		centering = #center
			ifTrue: [top _ bounds top + ((bounds height - fullBnds height) // 2)].
	] ifFalse: [
		top _ nextPlace.
		centering = #topLeft
			ifTrue: [left _ bounds left + totalInset].
		centering = #bottomRight
			ifTrue: [left _ bounds right - totalInset - fullBnds width].
		centering = #center
			ifTrue: [left _ bounds left + ((bounds width - fullBnds width) // 2)]].

	m position: (left + (m bounds left - fullBnds left)) @ (top + (m bounds top - fullBnds top)).
	^ space
