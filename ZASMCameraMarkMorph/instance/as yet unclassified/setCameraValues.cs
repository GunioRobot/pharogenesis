setCameraValues

	| camera |
	camera _ self cameraController.

	"ick... since one may fail to fully take due to constraints, retry"
	2 timesRepeat: [
		camera cameraPoint: (self valueOfProperty: #cameraPoint).
		camera cameraScale: (self valueOfProperty: #cameraScale).
	].

