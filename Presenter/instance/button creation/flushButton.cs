flushButton
	"for debugging only"

	| aButton |
	aButton _ EllipseMorph new extent: 41@25.
	aButton addMorphCentered: (StringMorph new contents: 'Flush') lock;
			color: (Color r: 0.548 g: 0.935 b: 0.935);
			on: #mouseUp send: #flushUp:with: to: self;
			setNameTo: 'Flush';
			setProperty: #scriptingControl toValue: true;
			setBalloonText: 'Don''t worry, you
can *never* go down the drain.
Clears out the Viewer and
flushes the viewer cache';
			beRepelling.
	^ aButton