updateImage
	"pinForm was made for right side.  Rotate/flip for other sides"

	bounds left < owner bounds left ifTrue:  "left side"
		[^ self image: (pinForm flipBy: #horizontal centerAt: 0@0)].
	bounds bottom > owner bounds bottom ifTrue:  "bottom"
		[^ self image: ((pinForm rotateBy: #left centerAt: 0@0)
								flipBy: #vertical centerAt: 0@0)].
	bounds right > owner bounds right ifTrue:  "right side"
		[^ self image: pinForm].
	bounds top < owner bounds top ifTrue:  "top"
		[^ self image: (pinForm rotateBy: #left centerAt: 0@0)].
self halt: 'uncaught pin geometry case'