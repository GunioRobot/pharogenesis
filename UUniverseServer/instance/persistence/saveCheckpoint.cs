saveCheckpoint
	"save a checkpoint"
	| tmpFile |
	saveDirectory deleteFileNamed: 'checkpoint.tmp'.
	
	tmpFile := saveDirectory newFileNamed: 'checkpoint.tmp'.
	(SmartRefStream on: tmpFile) nextPut: {universe.policy}; close.
	
	saveDirectory deleteFileNamed: 'checkpoint.die'.
	saveDirectory rename: 'checkpoint.tmp' toBe: 'checkpoint'.	
	saveDirectory deleteFileNamed: 'checkpoint.die'.
	