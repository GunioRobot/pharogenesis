updateFrom6726
	"self new updateFrom6726"
	"
	-Put back in the simplified Decompiler>>#decompileBlock:
	- deprecated #who
	- CompiledMethod>>#methodNode now sets Class and Selector for non-installed 
	  methods to Object/ CompiledMethod>>#defaultSelector
     - refactored ContextPart to not call #who
	- refactored ProcessBrowserPlus to not use #who
	- refactored ProcessBrowser to not use #who
	- simplified CompiledMethod>>#defaultSelector
	- String>>#hash now uses identityHasch as initial hash (needed for Behavior>>#hash)
	- moved numArgs: to Symbol, faster
	- add Behavior hash
	- simplify CompiledMethod: #defaultSelector, #equivalentTo:, #methodNode
	- add CompiledMethod>>#selector:
	- add iVarselector to MethodProperties, accessors
	- make MethodProperties compact again.
	"
	
	"I added a Variable... "
	MethodProperties becomeCompact.

	self script35.
	self flushCaches.
	