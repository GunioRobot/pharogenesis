colormapIfNeededFor: destForm
	"Return a ColorMap mapping from the receiver to destForm."
	"Note: This is very magical for now - we really need to switch
	to palettes here but as long as this isn't done we need something
	that works."
	| map nBits myBits |
	(self isExternalForm or:[destForm isExternalForm]) ifTrue:[
		^self colormapFromARGB mappingTo: destForm colormapFromARGB].
	self depth = destForm depth ifTrue:[^nil]. "no conversion"
	self depth <= 8 ifTrue:["Always map indexed"
		^ColorMap
			shifts: nil
			masks: nil
			colors: (Color colorMapIfNeededFrom: self depth to: destForm depth)].
	(self depth = 16 and:[destForm depth = 32]) ifTrue:["Expand bits"
		^ColorMap 
			shifts: #( 9 6 3 0) 
			masks: #(16r7C00 16r3E0 16r1F 0)].
	(self depth = 32 and:[destForm depth = 16]) ifTrue:["Contract bits"
		^ColorMap
			shifts: #(-9 -6 -3 0)
			masks: #(16rF80000 16rF800 16rF8 0)].
	"destForm is indexed, I am non-indexed"
	map _ Color colorMapIfNeededFrom: self depth to: destForm depth.
	map size = 512 ifTrue:[nBits _ 3].
	map size = 4096 ifTrue:[nBits _ 4].
	map size = 32768 ifTrue:[nBits _ 5].
	myBits _ depth == 16 ifTrue:[5] ifFalse:[8].
	^ColorMap
		shifts: {	(3 * nBits) - (3 * myBits).
				(2 * nBits) - (2 * myBits).
				(1 * nBits) - (1 * myBits).
				0}
		masks: {	(1 bitShift: nBits) - 1 bitShift: (3 * myBits - nBits).
				(1 bitShift: nBits) - 1 bitShift: (2 * myBits - nBits).
				(1 bitShift: nBits) - 1 bitShift: (1 * myBits - nBits).
				0}
		colors: map.