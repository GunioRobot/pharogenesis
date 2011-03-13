useKedamaFloatArray
"
	KedamaTurtleMorph useKedamaFloatArray.
"
	KedamaTurtleMorph allInstancesDo: [:e | e player ifNotNil: [e player turtles useKedamaFloatArray]].
