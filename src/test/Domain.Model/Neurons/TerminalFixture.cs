﻿// TODO: using org.neurul.Common.Test;
//using org.neurul.Cortex.Common;
//using org.neurul.Cortex.Domain.Model.Neurons;
//using System;
//using System.Linq;
//using Xunit;

//namespace works.ei8.Data.Tag.Domain.Model.Test.Neurons.TerminalFixture.given
//{
//    public abstract class Context : TestContext<Terminal>
//    {
//        protected Guid id;
//        protected Neuron presynapticNeuron;
//        protected Neuron postsynapticNeuron;
//        protected NeurotransmitterEffect effect;
//        protected float strength;

//        protected virtual Guid Id => this.id = this.id == Guid.Empty ? Guid.NewGuid() : this.id;
//        protected virtual Neuron PresynapticNeuron => this.presynapticNeuron = this.presynapticNeuron ?? new Neuron(Guid.NewGuid());
//        protected virtual Neuron PostsynapticNeuron => this.postsynapticNeuron = this.postsynapticNeuron ?? new Neuron(Guid.NewGuid());
//        protected virtual NeurotransmitterEffect Effect => this.effect = this.effect == NeurotransmitterEffect.NotSet ? NeurotransmitterEffect.Excite : this.effect;
//        protected virtual float Strength => this.strength = this.strength == 0 ? 1 : this.strength;
//    }

//    public abstract class ConstructingTerminalContext : Context
//    {
//        protected override bool InvokeWhenOnConstruct => false;

//        protected override void When() => this.sut = new Terminal(this.Id, this.PresynapticNeuron, this.PostsynapticNeuron, this.Effect, this.Strength);
//    }

//    public class When_constructing
//    {
//        public class When_empty_id : ConstructingTerminalContext
//        {
//            protected override Guid Id => Guid.Empty;

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_null_presynapticNeuron : ConstructingTerminalContext
//        {
//            protected override Neuron PresynapticNeuron => null;

//            [Fact]
//            public void Then_should_throw_argument_null_exception()
//            {
//                Assert.Throws<ArgumentNullException>(() => this.When());
//            }
//        }

//        public class When_inactive_presynapticNeuron : ConstructingTerminalContext
//        {
//            protected override void When()
//            {
//                this.PresynapticNeuron.Deactivate();
//                base.When();
//            }

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_presynapticNeuronId_is_equal_to_terminal_id : ConstructingTerminalContext
//        {
//            protected override Neuron PresynapticNeuron => this.presynapticNeuron = this.presynapticNeuron ?? new Neuron(this.Id);

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_null_postsynapticNeuron : ConstructingTerminalContext
//        {
//            protected override Neuron PostsynapticNeuron => null;

//            [Fact]
//            public void Then_should_throw_argument_null_exception()
//            {
//                Assert.Throws<ArgumentNullException>(() => this.When());
//            }
//        }

//        public class When_inactive_postsynapticNeuron : ConstructingTerminalContext
//        {
//            protected override void When()
//            {
//                this.PostsynapticNeuron.Deactivate();
//                base.When();
//            }

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_postsynapticNeuronId_is_equal_to_terminal_id : ConstructingTerminalContext
//        {
//            protected override Neuron PostsynapticNeuron => this.postsynapticNeuron = this.postsynapticNeuron ?? new Neuron(this.Id);

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_presynaptic_and_postsynaptic_are_equal : ConstructingTerminalContext
//        {
//            protected override Neuron PostsynapticNeuron => this.PresynapticNeuron;

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_notset_effect : ConstructingTerminalContext
//        {
//            protected override NeurotransmitterEffect Effect => NeurotransmitterEffect.NotSet;

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_excessive_strength : ConstructingTerminalContext
//        {
//            protected override float Strength => 1.001f;

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        public class When_insufficient_strength : ConstructingTerminalContext
//        {
//            protected override float Strength => 0f;

//            [Fact]
//            public void Then_should_throw_argument_exception()
//            {
//                Assert.Throws<ArgumentException>(() => this.When());
//            }
//        }

//        // TODO: transfer to cortex.sentry
//        //public class When_inactive_author : ConstructingTerminalContext
//        //{
//        //    protected override void When()
//        //    {
//        //        this.AuthorId.Deactivate(this.AuthorId);
//        //        base.When();
//        //    }

//        //    [Fact]
//        //    public void Then_should_throw_argument_exception()
//        //    {
//        //        Assert.Throws<ArgumentException>(() => this.When());
//        //    }
//        //}
//    }

//    public abstract class ConstructedTerminalContext : ConstructingTerminalContext
//    {
//        protected override bool InvokeWhenOnConstruct => true;
//    }

//    public class When_constructed : ConstructedTerminalContext
//    {
//        [Fact]
//        public void Then_should_contain_correct_id()
//        {
//            Assert.Equal(this.Id, this.sut.Id);
//        }

//        [Fact]
//        public void Then_should_contain_correct_presynapticNeuronId()
//        {
//            Assert.Equal(this.PresynapticNeuron.Id, this.sut.PresynapticNeuronId);
//        }

//        [Fact]
//        public void Then_should_contain_correct_postsynapticNeuronId()
//        {
//            Assert.Equal(this.PostsynapticNeuron.Id, this.sut.PostsynapticNeuronId);
//        }

//        [Fact]
//        public void Then_should_contain_correct_effect()
//        {
//            Assert.Equal(this.Effect, this.sut.Effect);
//        }

//        [Fact]
//        public void Then_should_contain_correct_strength()
//        {
//            Assert.Equal(this.Strength, this.sut.Strength);
//        }

//        [Fact]
//        public void Then_should_raise_terminal_created_event()
//        {
//            Assert.IsAssignableFrom<TerminalCreated>(this.sut.GetUncommittedChanges().Last());
//        }
//    }

//    public abstract class DeactivatedConstructedContext : ConstructedTerminalContext
//    {
//        protected override bool InvokeWhenOnConstruct => false;

//        protected override void When()
//        {
//            base.When();
//            this.sut.Deactivate();
//        }
//    }

//    public class When_deactivating_terminal
//    {
//        public class When_terminal_is_inactive : DeactivatedConstructedContext
//        {
//            protected override void When()
//            {
//                base.When();
//                this.sut.Deactivate();
//            }

//            [Fact]
//            public void Then_should_throw_invalid_operation_exception()
//            {
//                Assert.Throws<InvalidOperationException>(() => this.When());
//            }
//        }

//        public abstract class DeactivatingContext : ConstructedTerminalContext
//        {
//            protected override void When()
//            {
//                base.When();

//                this.sut.Deactivate();
//            }
//        }

//        public class When_terminal_is_active : DeactivatingContext
//        {
//            [Fact]
//            public void Then_should_raise_terminal_deactivated_event()
//            {
//                Assert.IsAssignableFrom<TerminalDeactivated>(this.sut.GetUncommittedChanges().Last());
//            }
//        }

//        // TODO: transfer to Sentry
//        // public class When_inactive_author : DeactivatingContext
//        //{
//        //    protected override Neuron AuthorParameter => this.authorParameter = this.authorParameter ?? new Neuron(Guid.NewGuid(), string.Empty);

//        //    protected override bool InvokeWhenOnConstruct => false;

//        //    protected override void When()
//        //    {
//        //        this.AuthorParameter.Deactivate(this.AuthorId);
//        //        base.When();
//        //    }

//        //    [Fact]
//        //    public void Then_should_throw_argument_exception()
//        //    {
//        //        Assert.Throws<ArgumentException>(() => this.When());
//        //    }
//        //}
//    }
//}

//// TODO: add validators for Terminals events constructors