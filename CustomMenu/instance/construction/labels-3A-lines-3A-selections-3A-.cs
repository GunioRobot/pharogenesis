labels: aString lines: linesArray selections: selectionsArray
	"This method allows the receiver to accept old-style SelectionMenu creation messages. It should be used only for backward compatibility during the MVC-to-Morphic transition. New code should be written using the other menu construction protocol such as addList:."

	| labelList |
	labelList _ (aString findTokens: String cr) asArray.
	1 to: labelList size do: [:i |
		self add: (labelList at: i) action: (selectionsArray at: i).
		(linesArray includes: i) ifTrue: [self addLine]].
