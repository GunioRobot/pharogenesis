ifProperUnwindSupportedElseSignalAboutToReturn
	"A really ugly hack to simulate the necessary unwind behavior for VMs not having proper unwind support"
	<primitive: 123>
	"The above indicates new EH primitives supported. In this case is identical to #value. Sender is expected to use [nil] ifProperUnwindSupportedElseSignalAboutToReturn."
	^ExceptionAboutToReturn signal.