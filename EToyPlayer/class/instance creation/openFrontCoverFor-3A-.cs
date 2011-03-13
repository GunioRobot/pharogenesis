openFrontCoverFor: anEToyHolder
	"From cold start, open up the imagineering studio, to its front page, but with the etoy represented by anEToyHolder already instantiated and ready to fly"
	"EToyPlayer openFrontCoverFor: DriveACar new"
	| w |
	w _ EToyWorld
		newBounds: (0@0 extent: (640@480 min: Display extent))
		color: (Color r: 0.937 g: 0.937 b: 0.937).
	w showCover.
	w openWithTitle: ''.  "no label"
