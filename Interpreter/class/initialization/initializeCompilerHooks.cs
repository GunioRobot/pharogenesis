initializeCompilerHooks
	"Interpreter initializeCompilerHooks"

	"compilerHooks[] indices:
	1	bool compilerActivateMethodHook(void)
	2	bool compilerFlushCacheHook(CompiledMethod *oldMethod)
	3	void compilerPreGCHook(int fullGCFlag)
	4	void compilerMapHook(int memStart, int memEnd)
	5	void compilerPostGCHook(void)
	6	void compilerProcessChangeHook(void)
	7	void compilerPreSnapshotHook(void)
	8	void compilerPostSnapshotHook(void)
	9	void compilerMarkHook(void)"

	CompilerHooksSize _ 10.