computeBounds

	| w ratio |

	w _ pasteUp width.
	self printSpecs scaleToFitPage ifTrue: [
		^0@0 extent: w@(w * self hOverW) rounded.
	].
	ratio _ 8.5 @ 11.
	self printSpecs landscapeFlag ifTrue: [
		ratio _ ratio transposed
	].
	^0@0 extent: (ratio * 72) rounded