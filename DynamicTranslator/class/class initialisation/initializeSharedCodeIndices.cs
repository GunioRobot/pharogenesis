initializeSharedCodeIndices		"DynamicTranslator initialize"

	CommonLocalReturnCase		_ ReturnTopFromBlock - 1.	"implicit return at end of block"
	CommonNonLocalReturnCase	_ ReturnTopFromMethod - 1.	"explicit return"
	CommonNormalSendCase		_ SendSpecialSelector - 1.
	CommonSuperCase			_ SingleExtendedSuper - 1.