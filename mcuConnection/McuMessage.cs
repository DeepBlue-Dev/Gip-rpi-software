using System;
using System.Collections.Generic;
using System.Collections;

namespace mcuConnection
{
    public record McuMessage
    {
        public InstructionResponses Response = InstructionResponses.Nop;   //  the message we received from the  µ-c
        public string ErrorResponse = String.Empty; //  the error response, if an error occurred 
        public readonly string Request;    //  the message that was sent
        private readonly InstructionCodes _opcode = InstructionCodes.Nop;     //  the opcode that was sent
        public string ParsedData;

        //  Constructor with a string request
        public McuMessage(string request)
        {
            this.Request = request;
        }

        //  constructor with opcode (recommended)
        public McuMessage(InstructionCodes code)
        {
            _opcode = code;
        }
        
        //  convert string request to char array for the Ascii.GetBytes() function
        public char[] RequestToCharArray()
        {
            if (Request is not null)
            {
                return Request.ToCharArray() ;
            }
            return new char[] { };  //  TODO test if this can cause unexpected behaviour
        }
        
        //  Convert opcode to char array for the Ascii.GetBytes() function
        public char[] OpCodeToCharArray()
        {
            if (_opcode is not InstructionCodes.Nop)
            {
                return new char[] {Convert.ToChar(_opcode)};
            }

            return new char[] { };  //  TODO test if this can cause unexpected behaviour
        }
        
        //  override the ToString method to our own liking
        public override string ToString()
        {
            if (Response is InstructionResponses.Nop && Request is null && _opcode is InstructionCodes.Nop)
            {
                return String.Empty;
            }

            return $"{Request};{_opcode};{Response}";
        }
        
        
    }
}