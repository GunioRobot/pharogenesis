clearMines: location

	| al tile |

	(self countFlags: location) = (self findMines: location) ifTrue:
		[
		{-1@-1. -1@0. -1@1. 0@1. 1@1. 1@0. 1@-1. 0@-1} do:
			[:offsetPoint |
			al _ location + offsetPoint.
			((al x between: 1 and: columns) and: [al y between: 1 and: rows]) ifTrue: [
				tile _ self tileAt: al.
				(tile mineFlag or: [tile switchState]) ifFalse:[
		   		self stepOnTile: al].].].
		].