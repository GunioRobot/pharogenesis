initializeCallingConventions
	"ExternalFunction initializeCallingConventions"
	#(
		(FFICallTypeCDecl 0)
		(FFICallTypeApi 1)
	) do:[:spec|
		FFIConstants declare: spec first from: Undeclared.
		FFIConstants at: spec first put: spec last.
	].
