initializeConfiguration		"DynamicTranslator initialize"

	"Tunable translator parameters.  Changes to these parameters take effect immediately
	in the Simulator.  Changes take effect in the compiled VM only after regenerating
	the C sources and recompiling to produce a new executable.  (The options manifest
	themselves as the [constant] conditions in 'if (0) {...} else {...}' and 'if (1) {...} else {...}'
	statements in the generated C code.  Corollary: this facility adds no overheads to the
	compiled VM, provided care is taken not to upset the CCodeGenerator's inlining
	mechanisms.)"

FreezeConfiguration = nil ifTrue: [FreezeConfiguration _ false].	"see DynInterp>>translateTestSuite"
FreezeConfiguration ifTrue: [Transcript cr; show: 'WARNING -- configuration frozen!'] ifFalse: [

	DecodeLiteralSelectors	_ true.		"lookup selectors at translation time"
	DecodeLiteralVariables	_ true.		"lookup global/class/pool associations at translation time"
	DecodeLiteralConstants	_ true.		"lookup literal frame constants at translation time"
	DecodeQuickConstants	_ true.		"use PushConstant opcode for all pushConstantX bytecodes"
	UseMethodCacheHashBits	_ true.		"preserve method cache across minor GCs"
	UseMacroOpcodes		_ true.		"use macro opcodes for common bytecode sequences"
	UseMacroPushBlock		_ true.		"optimise block creation sequences"
	UseInlineCache			_ true.		"enable the Fake Inline Cache"
	InlineCacheLimit		_ 128.		"do not link to methods larger than this (in bytecodes)"
	EagerInlineCacheFlush	_ false.		"invalidate translated method when ejected from method cache"
	UseInlineCacheDelay		_ true.		"delay linking in the inline cache"
	InlineCacheDelay		_ 5.			"number of method cache hits before inline cache is linked"
"Note: the following will also flush the inline cache if EagerInlineCacheFlush is true, but this is possibly NOT what we want
when the inline cache delay is operational"
	FlushCacheOnFullGC		_ true.		"flush method cache at every full GC"
	FlushCacheOnIncrGC		_ false.		"flush method cache at every incremental GC"

	ConstInvalidLinkage		_ 1333.		"guaranteed not to match a class, compact index, or ConstOne"

]