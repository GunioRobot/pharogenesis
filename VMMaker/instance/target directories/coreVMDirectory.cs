coreVMDirectory
	"return the target directory for the main VM sources, interp.c etc"
	| fd |
	fd _ self sourceDirectory directoryNamed: self class coreVMDirName.
	fd assureExistence.
	^ fd