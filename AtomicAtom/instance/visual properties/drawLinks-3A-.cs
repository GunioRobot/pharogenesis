drawLinks: aCanvas 
	"Draw the list of arrows"
	| lineWidth maxSize startPos linksCount endPos |
	maxSize _ self bounds extent // 2.
	startPos _ self bounds center.
links ifNotNil: [
	links
		do: [:link | 
			"for every link"
			linksCount _ (links
						select: [:item | item = link]) size.
			lineWidth _ linksCount * 2.
			endPos _ maxSize - lineWidth + linksCount * link + startPos.
			"draw the line"
			aCanvas
				line: startPos
				to: endPos
				width: lineWidth
				color: Color darkGray]]