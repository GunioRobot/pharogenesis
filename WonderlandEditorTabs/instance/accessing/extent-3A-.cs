extent: aPoint

	| newPoint |

	bounds extent = aPoint
		ifFalse: [
			self changed.

			newPoint _ (aPoint x)@(aPoint y - 20).

			myScriptEditor getMorph extent: newPoint.
			myActorViewer extent: newPoint.
			myQuickReference getMorph extent: newPoint.

			bounds _ bounds topLeft extent: aPoint.
			self layoutChanged.
			self changed
				].
