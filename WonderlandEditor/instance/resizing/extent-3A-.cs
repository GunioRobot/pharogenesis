extent: aPoint

	| newPoint aMorph |

	bounds extent = aPoint
		ifFalse: [
			self changed.

			newPoint _ aPoint.
			(aPoint x < 370) ifTrue: [ newPoint _ 370@(aPoint y) ].
			(aPoint y < 130) ifTrue: [ newPoint _ (newPoint x)@130 ].

			aMorph _ myActorBrowser getMorph.
			aMorph extent: 140@((newPoint y) - 52).
			aMorph position: (self position + (0@50)).

			myTabs extent: (newPoint x - 142)@(newPoint y - 4).
			myTabs position: (self position + (142@0)).

			bounds _ bounds topLeft extent: newPoint.
			self layoutChanged.
			self changed.
				].
