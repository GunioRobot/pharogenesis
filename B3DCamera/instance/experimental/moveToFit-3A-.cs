moveToFit: aScene
	"Move the camera to fit the given scene. Experimental."
	| distance center |
	self setTargetFrom: aScene.
	center _ (aScene boundingBox origin + aScene boundingBox corner) * 0.5.
	distance _ (aScene boundingBox origin - center) length * 1.3.
	distance _ distance / (target - position) length.
	"self inform:'Distance ', distance printString."
	self changeDistanceBy: distance.