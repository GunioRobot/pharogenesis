follow: locationBlock while: durationBlock bitsBehind: initialBitsBehind startingLoc: loc
   "Move an image around on the Display. Restore the background continuously without causing flashing. The argument, locationBlock, supplies each new location, and the argument, durationBlock, supplies true to continue or false to stop. This variant takes the bitsBehind as an input argument, and returns the final saved saved bits as method value."

   | location rect1 save1 save1Blt buffer bufferBlt newLoc rect2 bothRects |
   location _ loc.
   rect1 _ location extent: self extent.
   save1 _ initialBitsBehind.
   save1Blt _ BitBlt toForm: save1.
   buffer _ Form extent: self extent*2 depth: Display depth.  "Holds overlapping region"
   bufferBlt _ BitBlt toForm: buffer.
   self displayOn: Display at: location rule: Form paint.
   [durationBlock value] whileTrue: [
		newLoc _ locationBlock value.
		newLoc ~= location ifTrue: [
			rect2 _ newLoc extent: self extent.
			bothRects _ rect1 merge: rect2.
			(rect1 intersects: rect2)
				ifTrue: [  "when overlap, buffer background for both rectangles"
					bufferBlt copyFrom: bothRects in: Display to: 0@0.
					bufferBlt copyFrom: save1 boundingBox in: save1 to: rect1 origin - bothRects origin.
					"now buffer is clean background; get new bits for save1"
					save1Blt copy: (0@0 extent: self extent) from: rect2 origin - bothRects origin in: buffer.
					self displayOnPort: bufferBlt at: rect2 origin - bothRects origin rule: Form paint.
					Display copy: bothRects from: 0@0 in: buffer rule: Form over]
				ifFalse: [  "when no overlap, do the simple thing (both rects might be too big)"
					Display copy: (location extent: save1 extent) from: 0@0 in: save1 rule: Form over.
					save1Blt copyFrom: rect2 in: Display to: 0@0.
					self displayOn: Display at: newLoc rule: Form paint].
			location _ newLoc.
			rect1 _ rect2]].

	^ save1 displayOn: Display at: location
