veryDeepCopyWith: deepCopier
	| camera page |
	"Keep the same camera???"
 
	(camera _ self cameraController) ifNotNil: [
		(deepCopier references includesKey: camera) ifFalse: [
			"not recorded, outside our tree, use same camera"
			deepCopier references at: camera put: camera]].
	(page _ self valueOfProperty: #bookPage) ifNotNil: [
		(deepCopier references includesKey: page) ifFalse: [
			deepCopier references at: page put: page]].

	^ super veryDeepCopyWith: deepCopier

