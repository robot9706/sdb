//
// The MIT License (MIT)
//
// Copyright (c) 2018 Alex Rønne Petersen
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System.Collections.Generic;

namespace Mono.Debugger.Client.Commands
{
    sealed class QuitCommand : Command
    {
        public override string[] Names
        {
            get { return new[] { "quit", "bye", "exit" }; }
        }

        public override string Summary
        {
            get { return "Exit the debugger."; }
        }

        public override string Syntax
        {
            get { return "quit|bye|exit [!]"; }
        }

        public override string Help
        {
            get
            {
                return "Exits the debugger. If the '!' argument is given, any active inferior\n" +
                       "process will be killed; otherwise, the command will refuse to quit if an\n" +
                       "inferior process is active.";
            }
        }

        public override void Process(string args)
        {
            if (Debugger.State != State.Exited && !args.StartsWith("!"))
            {
                Log.Error("An inferior process is active");
                return;
            }

            CommandLine.Stop = true;
        }
    }
}
