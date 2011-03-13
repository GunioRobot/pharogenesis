createBlock: env

	^ BlockClosure new
		env: env;
		method: self