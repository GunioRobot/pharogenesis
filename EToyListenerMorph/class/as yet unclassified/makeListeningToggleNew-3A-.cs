makeListeningToggleNew: activeMode

	| background c baseExtent bgExtent botCent factor len endPts base |

	factor _ 2.
	bgExtent _ (50@25) * factor.
	baseExtent _ (15@15) * factor.
	background _ Form extent: bgExtent depth: 8.
	botCent _ background boundingBox bottomCenter.
	c _ background getCanvas.
"c fillColor: Color white."
	base _  (botCent - (baseExtent // 2)) extent: baseExtent.
	c
		fillOval: base
		color: Color black 
		borderWidth: 0 
		borderColor: Color black.
	activeMode ifTrue: [
		len _ background boundingBox height - 15.
		endPts _ {botCent - (len@len). botCent - (len negated@len)}.
		endPts do: [ :each |
			c line: botCent to: each width: 2 color: Color black.
		].
		endPts do: [ :each |
			#(4 8 12) do: [ :offset |
				c frameOval: (each - offset corner: each + offset) color: Color red
			].
		].
	].
"background asMorph openInWorld."
	^background


	