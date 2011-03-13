updateFrom6727
	"self new updateFrom6727"
	"
	- deprecate behavior>>#selectorAtMethod:setClass: 
	- deprecate ContextPart>>#mclass (use methodClass, like in CompiledMethod)
	- deprecate ContextPart>>#methodSelector (use #selector, like in CompiledMethod)
	- deprecate MethodContext>>#answer: (comment indicates 'will soon be removed'
	- refactor to not call deprecated methods.
	- Fast #who part 2: Selector from compiledMethod.
	- Forward from ContextPart to method (selector, decompile.)
       no need to search anymore 
     - installed methods now get selector/class set.
	"
	"recompile"
	self script36.
	self flushCaches.
	Compiler recompileAll.
	