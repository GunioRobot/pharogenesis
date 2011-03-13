transform2By: aDisplayTransform clippingTo: aClipRect during: aBlock smoothing: cellSize

	"an attempt to use #displayInterpolatedOn: instead of WarpBlt."

	| patchRect subCanvas pureRect biggerPatch biggerClip interForm |

	self flag: #bob.		"added to Canvas in hopes it will work for Nebraska"
	(aDisplayTransform isPureTranslation) ifTrue: [
		^aBlock value: (self copyOffset: aDisplayTransform offset negated truncated
							clipRect: aClipRect)
	].
	"Prepare an appropriate warp from patch to aClipRect"
	pureRect _ (aDisplayTransform globalBoundsToLocal: aClipRect).
	patchRect _ pureRect rounded.
	patchRect area = 0 ifTrue: [^self]. 	"oh, well!"
	biggerPatch _ patchRect expandBy: 1.
	biggerClip _ (aDisplayTransform localBoundsToGlobal: biggerPatch) rounded.

	"Render the submorphs visible in the clipping rectangle, as patchForm"
	subCanvas _ FormCanvas extent: biggerPatch extent depth: self depth.
	self isShadowDrawing ifTrue: [
		subCanvas shadowColor: self shadowColor
	].

	"this biggerPatch/biggerClip is an attempt to improve positioning of the final image in high magnification conditions. Since we cannot grab fractional pixels from the source, take one extra and then take just the part we need from the expanded form"

	subCanvas 
		translateBy: biggerPatch topLeft negated rounded
		during: [ :offsetCanvas | aBlock value: offsetCanvas].
	interForm _ Form extent: biggerClip extent depth: self depth.
	subCanvas form 
		displayInterpolatedIn: interForm boundingBox
		on: interForm.
	self 
		drawImage: interForm 
		at: aClipRect origin 
		sourceRect: (aClipRect origin - biggerClip origin extent: aClipRect extent)

