layoutRow: mList lastRowBase: lastRowBase

	| rowBase nextX |
	rowBase _ self rowBaseFor: mList lastRowBase: lastRowBase.
	nextX _ bounds left + borderWidth + padding.
	mList do: [:m |
		m position: nextX @ ((lastRowBase + rowBase - m fullBounds height) // 2).
		nextX _ nextX + m fullBounds width + padding].
	^ rowBase
