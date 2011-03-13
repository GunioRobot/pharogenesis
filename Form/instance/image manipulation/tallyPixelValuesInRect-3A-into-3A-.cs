tallyPixelValuesInRect: destRect into: valueTable
	"Tally the selected pixels of this form into the valueTable, which is
	a bitmap similar to a color map.  Since the underlying BitBlt function
	that performs the tally does not do bit-boundary clipping, the
	tallies for any word-boundary fringes must be subtracted."
	| fringeTallies pixPerWord |
	self tallyPixelValuesPrimitive: destRect into: valueTable.
	pixPerWord _ 32//depth.
	destRect left\\pixPerWord ~= 0 ifTrue:
		[fringeTallies _ (self copy:
			((destRect left//pixPerWord*pixPerWord)@destRect top extent: pixPerWord@destRect height)) tallyPixelValues.
		"Extra nulls in the fringeTallies about to be subtracted"
		valueTable at: 1 put: (valueTable at: 1) + (destRect left\\pixPerWord*destRect height).
		1 to: fringeTallies size do:
			[:i | valueTable at: i put: (valueTable at: i) - (fringeTallies at: i)]].
	destRect right\\pixPerWord ~= 0 ifTrue:
		[fringeTallies _ (self copy:
			((destRect right)@destRect top extent: pixPerWord@destRect height)) tallyPixelValues.
		"Extra nulls in the fringeTallies about to be subtracted"
		valueTable at: 1 put: (valueTable at: 1) + ((pixPerWord-(destRect right\\pixPerWord))*destRect height).
		1 to: fringeTallies size do:
			[:i | valueTable at: i put: (valueTable at: i) - (fringeTallies at: i)]].
	^ valueTable

"Move a little rectangle around the screen and print its tallies...
| r tallies nonZero |
Cursor blank showWhile: [
[Sensor anyButtonPressed] whileFalse:
	[r _ Sensor cursorPoint extent: 10@10.
	Display border: (r expandBy: 2) width: 2 rule: Form reverse fillColor: nil.
	tallies _ (Display copy: r) tallyPixelValues.
	nonZero _ (1 to: tallies size) collect: [:i | i -> (tallies at: i)]
			thenSelect: [:assn | assn value > 0].
	nonZero printString , '          ' displayAt: 0@0.
	Display border: (r expandBy: 2) width: 2 rule: Form reverse fillColor: nil]]
"