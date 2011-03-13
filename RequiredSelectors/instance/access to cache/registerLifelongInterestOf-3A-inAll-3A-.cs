registerLifelongInterestOf: client inAll: classes 
	self noteInterestOf: client inAll: classes.
	classes do: [:cl | client toFinalizeSend: #lostOneInterestIn: to: self with: cl].