primCreateRenderer: flags x: x y: y w: w h: h
	<primitive: 'primitiveCreateRendererFlags' module:'B3DAcceleratorPlugin'>
	"If the above fails, retry with the old interface"
	^self primCreateRendererSW: (flags anyMask: B3DSoftwareRenderer)
		hw: (flags anyMask: B3DHardwareRenderer)
		x: x y: y w: w h: h