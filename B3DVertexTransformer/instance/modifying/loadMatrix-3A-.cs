loadMatrix: aMatrix
	currentMatrix loadFrom: aMatrix.
	needsUpdate := true.