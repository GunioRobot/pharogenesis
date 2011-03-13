openOn: anEToyHolder
	"EToyPlayer openOn: EToyHolder new"

	| w sizeWanted |
	sizeWanted _ anEToyHolder playfield valueOfProperty: #worldSize.
	sizeWanted ifNil: [sizeWanted _ 640@480].
	w _ EToyWorld
		newBounds: (0@0 extent: (sizeWanted min: Display extent))
		color: (Color r: 0.937 g: 0.937 b: 0.937).

	self new initializeFor: anEToyHolder inWorld: w.
	w openWithTitle: anEToyHolder titleForFrontCover
