emitGlobalStructFlagOn: aStream
	"Define SQ_USE_GLOBAL_STRUCT before including the header."

	aStream nextPutAll: '#define SQ_USE_GLOBAL_STRUCT 1'; cr; cr