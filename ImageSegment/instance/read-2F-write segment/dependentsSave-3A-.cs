dependentsSave: dummy
	"Object that have dependents are supposed to be instances of subclasses of Model.  But, class Objects still provides 'Global Dependents', and some people still use them.  When both the model and the dependent are in a project that is being saved, remember them, so we can hook them up when this project is loaded in."

	| dict proj list |
	proj _ dummy project.
	dict _ Dictionary new.
	DependentsFields associationsDo: [:assoc |
		(dummy references includesKey: assoc key) ifTrue: [
			list _ assoc value select: [:dd | dummy references includesKey: dd].
			list size > 0 ifTrue: [dict at: assoc key put: list]]].

	dict size > 0 ifTrue: [
		proj projectParameterAt: #GlobalDependentsInProject put: dict].
