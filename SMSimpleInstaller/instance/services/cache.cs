cache
	"Download object into cache if needed.
	Set the directory and fileName for subsequent unpacking and install."

	packageRelease ensureInCache ifTrue: [
		fileName _ packageRelease downloadFileName.
		dir _ packageRelease cacheDirectory]