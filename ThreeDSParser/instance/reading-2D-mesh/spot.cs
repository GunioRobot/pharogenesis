spot
	"Subchunk of light"

	| spot result |
	spot := Dictionary new.
	spot 
		at: #target put: self vector3;
		at: #hotspotAngle put: self float;
		at: #falloffAngle put: self float.
	result := self recognize: #(
		(16r4651 flag rectangular)
		(16r4652 flag overshoot)
		(16r4653 flag projector)) as: Dictionary.
	spot at: #rectangular put:(result at: #rectangular ifAbsent: [false]).
	spot at: #overshoot put: (result at: #overshoot ifAbsent: [false]).
	spot at: #projector put: (result at: #projector ifAbsent: [false]).
	^spot