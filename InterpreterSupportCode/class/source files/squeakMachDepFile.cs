squeakMachDepFile

	^ '/* Platform/compiler dependent support for dynamic translation. */

#if defined(__GNUC__)

  /* GNU C on any platform */

# define initOp(O)	(opcodeAddress= (int)(&&_op_##O) + 1)
# if defined(JUMP_ALIGN_BYTE)
    /* guarantee an even address for opcode start, then 1-byte no-op */
#   define beginOp(O)	asm (".align 2"); _op_##O: asm("nop")
# else
#   define beginOp(O)	_op_##O:
# endif
# if defined(JUMP_ALIGN_STRICT)
#   define nextOp()	({ goto *(void *)(*(int *)(localIP+= 4)-1); 0; })
# else
#   define nextOp()	({ goto *(void *)(*(int *)(localIP+= 4)); 0; })
# endif
# define endOp(O)	nextOp()

#elif defined (macintosh)

# if defined (__POWERPC__)

    /* PowerMac: assumes CodeWarrior 8 or later (other compilers might barf) */

#   pragma internal on

    static asm int _setLabel(register int *ap, register int tmp)
    {
      mflr tmp			// address of insn after call site
      addi tmp, tmp, 9	// address of opcode start + tag bit
      stw  tmp, 0(ap)	// &opcode -> *store
      li   r3, 1		// answer "true"
      blr
    }

    static asm int _gotoLabel(register int ip)
    {
      mtlr ip	// destination address
      blr		// dispatch
    }

#   pragma internal off

# else /*!__POWERPC__*/

    /* 68K Mac: assumes CodeWarrior 8 or later (other compilers might barf) */

    static asm int _setLabel(register int *ap, int ignored)
    {
      // the following is gross, but the 68K has a short branch range
      // that is just large enough to be used in a few cases.  we have
      // to find the opcode start address by "disassembling" the code
      // following the call to _setLabel.  (efficiency is irrelevant.)
      move.l	(sp), a0	// insn after call site
	l:move.w	(a0)+, d0	// next insn
	  and.w		#0xFF00, d0	// lose disp8
	  cmp.w		#0x6600, d0	// BNE[.S]?
	  bne.s		l			// not yet
	  move.w	-2(a0), d0	// BNE[.S]
	  tst.b		d0			// disp = 0?
	  bne.s		s			// no [disp8]
	  addq.l	#2, a0		// yes [disp16]
	s:move.l	a0, d0		// opcode
	  addq.l	#1, d0		// + tag
	  move.l	4(sp), a0	// &store
      move.l	d0, (a0)	// op -> *store
      rts					// ^true
    }

    static asm int _gotoLabel(register int ip)
    {
      // I think this is optimal (speedwise), but my 68k is very rusty.
      // (the 68020 can probably do the double indirection with index in
      // a single instruction, but I''m not convinced it''s any faster.)
      // please submit a better (i.e. faster) solution if you have one!
      addq.l	#4, sp		// drop ret addr
      move.l	(sp)+, a0	// pop ip
      jmp		-1(a0)		// dispatch = ip - tag
    }

# endif /*!__POWERPC__*/

# define initOp(O)	_setLabel(&opcodeAddress, 0)
# define beginOp(O)
# define nextOp()	_gotoLabel(*(int *)(localIP+= 4))
# define endOp(O)	nextOp()

#else
# error your platform/compiler is not supported
#endif
'.