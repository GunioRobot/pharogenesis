discardVMConstruction
	"Discard the virtual machine construction classes and the Smalltalk-to-C translator. These are only needed by those wishing to build or study the Squeak virtual machine, or by those wishing to construct new primitives via Smalltalk-to-C translation.
Updated to suit 2.8 TPR"

	"remove the code for virtual machines"
	Smalltalk removeKey: #InterpreterLog ifAbsent: [].

	"remove the Smalltalk-to-C translator"
	Smalltalk at: #CCodeGenerator ifPresent: [:codeGen | codeGen removeCompilerMethods].
	SystemOrganization removeCategoriesMatching: 'VMConstruction-*'.
	SystemOrganization removeCategoriesMatching: 'Squeak-Plugins'.
