translate: fileName doInlining: inlineFlag doAssertions: assertionFlag
	"Time millisecondsToRun: [
		DynamicInterpreter translate: 'translator.c' doInlining: false doAssertions: false.
		Smalltalk beep]"

	"Time millisecondsToRun: [
		DynamicInterpreter translate: 'translator.c' doInlining: false doAssertions: true.
		Smalltalk beep]"

	"Time millisecondsToRun: [
		DynamicInterpreter translate: 'translator.c' doInlining: true doAssertions: true.
		Smalltalk beep]"

	"Time millisecondsToRun: [
		DynamicInterpreter translate: 'translator.c' doInlining: true doAssertions: false.
		Smalltalk beep]"

	self	translate: fileName
		doInlining: inlineFlag
		doAssertions: assertionFlag
		fromClasses: (OrderedCollection new
				add: BitBltSimulation;
				add: ObjectMemory;
				add: DynamicInterpreterState;
				add: DynamicContextCache;
				add: DynamicTranslator;
				add: DynamicInterpreter;
			yourself)