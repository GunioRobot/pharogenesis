scaleBy: evt 
	"up-down is scale. 3/26/97 tk Now a slider on the right."
	| pt temp cy oldRect amt myBuff |

	myBuff _ self get: #buff for: evt.
	pt _ evt cursorPoint - bounds center.
	cy _ bounds height * 0.5.
	oldRect _ myBuff boundingBox expandBy: myBuff extent * cumMag / 2.
	amt _ pt y abs < 12
				ifTrue: ["detent"
					1.0]
				ifFalse: [pt y - (12 * pt y abs // pt x)].
	amt _ amt asFloat / cy + 1.0.
	temp _ myBuff
				rotateBy: cumRot
				magnify: amt
				smoothing: 2.
	cumMag > amt
		ifTrue: ["shrinking"
			oldRect _ oldRect translateBy: paintingForm center - oldRect center + myBuff offset.
			paintingForm
				fill: (oldRect expandBy: 1 @ 1)
				rule: Form over
				fillColor: Color transparent].
	temp displayOn: paintingForm at: paintingForm center - temp center + myBuff offset.
	scaleButton position: scaleButton position x @ (evt cursorPoint y - 6).
	self render: bounds.
	cumMag _ amt