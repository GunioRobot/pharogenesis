matrix: aMatrixTransform atFrame: frameNumber
	"self position: aMatrixTransform offset atFrame: frameNumber."
	self matrixData at: frameNumber put: aMatrixTransform.